import React from "react";
import { CountdownCircleTimer } from "react-countdown-circle-timer"

const CountDown = (props) => {
  const { remaining, otp } = props;

  return (
    <div className="timer-wrapper">
      <CountdownCircleTimer
        isPlaying
        duration={30}
        initialRemainingTime={remaining}
        colors={[["#004777", 0.33], ["#F7B801", 0.33], ["#A30000"]]}
      >
        {() => <h1>{otp}</h1>}
      </CountdownCircleTimer>
    </div>
  )
}

export default CountDown;