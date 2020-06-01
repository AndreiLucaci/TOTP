import React, { useState } from "react";
import moment from "moment";

const Identity = (props) => {
  const [userId, setUserId] = useState("");
  const [useNow, setUseNow] = useState(true);
  const [dateTime, setDateTime] = useState(
    moment().format("YYYY-MM-DD[T]HH:mm:ss")
  );

  const { onSubmit } = props;

  const getUtcDateTime = () => {
    if (!useNow) {
      const utc = moment.utc(dateTime);
      if (!utc.isValid()) {
        alert("Input date time is invalid!");
        return null;
      }

      return utc.format();
    }

    return null;
  };

  const onFormSubmit = (e) => {
    e.preventDefault();
    const utcDateTime = getUtcDateTime();
    if (userId && (useNow || utcDateTime)) {
      onSubmit({
        userId,
        useNow,
        dateTime: utcDateTime,
      });
    }
  };

  const updateCheckbox = (e) => {
    setUseNow(e.checked);
    if (!e.checked) {
      setDateTime(moment().format("YYYY-MM-DD[T]HH:mm:ss"));
    }
  };

  return (
    <form
      className="input-group mb-3 d-flex flex-row"
      onSubmit={onFormSubmit}
      style={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <div className="p-2">
        <input
          placeholder="Insert user ID"
          aria-label="Insert user ID"
          aria-describedby="basic-addon2"
          className="form-control"
          onChange={(e) => setUserId(e.target.value)}
        />
      </div>
      {/* <div className="p-2" style={{ position: "relative", top: "4px" }}>
        <label htmlFor="checkbox" style={{ marginRight: "10px" }}>
          Use server NOW!
        </label>
        <input
          type="checkbox"
          id="checkbox"
          checked={useNow}
          onChange={updateCheckbox}
        />
      </div>
      <div className="p-2">
        <input
          type="datetime-local"
          className="form-control"
          onChange={(e) => setDateTime(e.target.value)}
          disabled={useNow}
        />
      </div> */}
      <div className="p-2">
        <button className="btn btn-outline-secondary" type="submit">
          GENERATE!
        </button>
      </div>
    </form>
  );
};

export default Identity;
