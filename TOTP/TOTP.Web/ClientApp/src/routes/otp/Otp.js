import React, { useState } from "react";
import { CountdownCircleTimer } from "react-countdown-circle-timer";

const Otp = (props) => {
  const [userId, setUserId] = useState("");
  const [remaining, setRemaining] = useState(0);
  const [otp, setOtp] = useState("");
  const [showCountdown, setShowCountdown] = useState(false);

  const fetchDataForCountDown = async () => {
    if (!userId) {
      return;
    }

    const response = await fetch(
      `api/otp?userId=${encodeURIComponent(userId)}`
    );

    const data = await response.json();
    if (data.successful) {
      setRemaining(data.validSecondsLeft);
      setOtp(data.otpPassword);
      setShowCountdown(true);
    } else {
      setShowCountdown(false);
      alert(`OTP failed for ${userId}!`);
    }
  };

  const getOtp = () => {
    if (userId) {
      fetchDataForCountDown();
    }
  };

  return (
    <div>
      <div>
        <div>
          <div className="input-group mb-3">
            <input
              type="text"
              className="form-control"
              placeholder="Insert user ID"
              aria-label="Insert user ID"
              aria-describedby="basic-addon2"
              onChange={(e) => setUserId(e.target.value)}
            ></input>
            <div className="input-group-append">
              <button
                className="btn btn-outline-secondary"
                type="button"
                onClick={getOtp}
              >
                GENERATE!
              </button>
            </div>
          </div>
        </div>
        {showCountdown ? (
          <div
            className="container"
            style={{
              display: "flex",
              "justify-content": "center",
              "align-items": "center",
              height: "60vh",
            }}
          >
            <CountdownCircleTimer
              isPlaying={true}
              size={300}
              strokeWidth={12}
              onComplete={() => {
                getOtp();
                return [true];
              }}
              duration={30}
              initialRemainingTime={remaining}
              colors={[["#004777", 0.33], ["#F7B801", 0.33], ["#A30000"]]}
            >
              {() => <h1>{otp}</h1>}
            </CountdownCircleTimer>
          </div>
        ) : null}
      </div>
    </div>
  );
};

export default Otp;
