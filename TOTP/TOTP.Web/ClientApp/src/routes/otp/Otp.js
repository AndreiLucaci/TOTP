import React, { useState } from 'react';
import CountDown from '../../components/countdown';

const Otp = (props) => {
    const [countdown, setCountdown] = useState(<></>);
    const onComplete = () => {

    }

    const getCountDown = (remaining) => {
        const newCountdown = <CountDown remaining={remaining} onComplete={onComplete}></CountDown>
        setCountdown(newCountdown);
    }

    return (<div>
        <div>
            <div class="input-group mb-3">
                <input type="text" class="form-control" placeholder="Insert user ID" aria-label="Insert user ID" aria-describedby="basic-addon2">
                </input>
                <div class="input-group-append">
                    <button class="btn btn-outline-secondary" type="button" onClick={getCountDown}>GENERATE!</button>
                </div>
            </div>
            {countdown}
        </div>
    </div>)
}

export default Otp;