import React from 'react'
import { Link } from 'react-router-dom'
import './Home.css'

const Home = (props) => {
  return (
    <div class='home'>
      <h1>Welcome to OTP generator</h1>
      <p>The OTP is generated using a TOTP (Time-based One-time Password algorithm) implementation.</p>
      <h2>Try it out!</h2>
      <Link to="/otp">Go to OTP Generator</Link>
      <h2> Reasons of choosing TOTP as an implementation:</h2>
      <p>The reasons of choosing TOTP are pretty simple: TOTP is a given standard on the internet.</p>
      <blockquote class="blockquote">
        <p class="mb-0">"The Time-based One-time Password algorithm (TOTP) is an extension of the HMAC-based One-time Password algorithm (HOTP) generating a one-time password (OTP) by instead taking uniqueness from the current time. It has been adopted as Internet Engineering Task Force (IETF)[1] standard RFC 6238,[1] is the cornerstone of Initiative for Open Authentication (OATH), and is used in a number of two-factor authentication (2FA) systems."</p>
        <footer class="blockquote-footer"><cite title="Time-based One-time Password algorithm on Wikipedia"><a href="https://en.wikipedia.org/wiki/Time-based_One-time_Password_algorithm">Wikipedia</a></cite></footer>
      </blockquote>
      <h2>Implementation details:</h2>
      <p>TOTP implementation makes use of two algorithms:</p>
      <ul class="list-unstyled">
        <li>
          <p class="lead">
            HOTP - <a href="https://tools.ietf.org/html/rfc4226">An HMAC-Based One-Time Password Algorithm</a>
          </p>
          <blockquote class="blockquote text-center">
            <p class="mb-0">"The document describes an algorithm to generate one-time password
            values, based on Hashed Message Authentication Code (HMAC).  A
            security analysis of the algorithm is presented, and important
            parameters related to the secure deployment of the algorithm are
            discussed.  The proposed algorithm can be used across a wide range of
            network applications ranging from remote Virtual Private Network
            (VPN) access, Wi-Fi network logon to transaction-oriented Web
   applications."</p>
            <footer class="blockquote-footer"><cite title="HMAC-Based One-Time Password Algorithm"><a href="https://tools.ietf.org/html/rfc4226">HMAC-Based One-Time Password Algorithm</a></cite></footer>
          </blockquote>
        </li>
        <li>
          <p class="lead">
            TOTP draft 6 - <a href="https://tools.ietf.org/id/draft-mraihi-totp-timebased-06.html">Time-based One-time Password Algorithm</a>
          </p>
          <blockquote class="blockquote text-center">
            <p class="mb-0">"The document describes an extension of one-time password (OTP) algorithm, namely the HAMC-Based One-Time Password (HOTP) Algorithm as defined in RFC 4226, to support time-based moving factor. The HOTP algorithm specifies an event based OTP algorithm where the moving factor is an event counter. The present work bases the moving factor on a time value. A time-based variant of the OTP algorithm provides short-lived OTP values, which are desirable for enhanced security.

The proposed algorithm can be used across a wide range of network applications ranging from remote Virtual Private Network (VPN) access, Wi-Fi network logon to transaction-oriented Web applications. The authors believe that a common and shared algorithm will facilitate adoption of two-factor authentication on the Internet by enabling interoperability across commercial and open-source implementations."</p>
            <footer class="blockquote-footer"><cite title="Time-based One-time Password Algorithm"><a href="https://tools.ietf.org/id/draft-mraihi-totp-timebased-06.html">Time-based One-time Password Algorithm</a></cite></footer>
          </blockquote>
        </li>
      </ul>
    </div >
  );
}

export default Home;
