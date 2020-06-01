import React, { useState, useEffect } from "react";
import { CountdownCircleTimer } from "react-countdown-circle-timer";
import Identity from "../../components/identity";
import moment from "moment";

const Otp = (props) => {
  const [remaining, setRemaining] = useState(0);
  const [otp, setOtp] = useState("");
  const [showCountdown, setShowCountdown] = useState(false);
  const [identity, setIdentity] = useState(null);
  const [seconds, setSeconds] = useState(0);
  const [secondsFormatted, setSecondsFormatted] = useState("");
  const countdownStep = 1000;

  const setSecondsWithFormat = (inputSeconds) => {
    setSeconds(inputSeconds - 1);
    setSecondsFormatted(` - ${inputSeconds - 1} - `);
  };

  const fetchDataForCountDown = async (inputIdentity) => {
    if (!inputIdentity) {
      return;
    }

    const urlSearchParams = new URLSearchParams();
    const { userId, useNow, dateTime } = inputIdentity;

    urlSearchParams.append("userId", userId);
    if (!useNow) {
      urlSearchParams.append("dateTime", dateTime);
    }

    const response = await fetch(`api/otp?${urlSearchParams.toString()}`);

    const data = await response.json();
    if (data.successful) {
      setOtp(data.otpPassword);
      setSecondsWithFormat(data.validSecondsLeft);
      setRemaining(data.validSecondsLeft);
      setShowCountdown(true);
    } else {
      setShowCountdown(false);
      alert(`OTP failed for ${userId}!`);
    }
  };

  const getOtp = (identity) => {
    setIdentity(identity);

    if (identity && identity.userId && (identity.useNow || identity.dateTime)) {
      fetchDataForCountDown(identity);
    }
  };

  const refreshOTP = () => {
    let newIdentity = null;

    if (!identity.useNow) {
      newIdentity = { ...identity };
      newIdentity.dateTime = moment
        .utc(identity.dateTime)
        .add(30, "seconds")
        .toISOString();
      setIdentity(newIdentity);
    }

    getOtp({ ...(newIdentity || identity) });
  };

  useEffect(() => {
    const intervalId = setInterval(() => {
      if (identity && identity.userId && otp) {
        setSecondsWithFormat(seconds);
      }
    }, countdownStep);

    return () => clearInterval(intervalId);
  });

  return (
    <div>
      <div>
        <div>
          <div className="input-group mb-3">
            <Identity onSubmit={getOtp} />
          </div>
        </div>
        {showCountdown ? (
          <div
            className="container"
            style={{
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              height: "60vh",
            }}
          >
            <CountdownCircleTimer
              isPlaying={true}
              size={300}
              strokeWidth={12}
              onComplete={() => {
                refreshOTP();
                return [true];
              }}
              duration={30}
              initialRemainingTime={remaining}
              colors={[["#004777", 0.33], ["#F7B801", 0.33], ["#A30000"]]}
            >
              {() => (
                <div style={{ textAlign: "center" }}>
                  <h1>{otp}</h1>
                  <h3>{secondsFormatted}</h3>
                </div>
              )}
            </CountdownCircleTimer>
          </div>
        ) : null}
      </div>
    </div>
  );
};

export default Otp;
