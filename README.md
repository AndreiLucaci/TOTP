# TOTP
This is an implementation of OTP using a TOTP algorithm

## Implementation details:
### TOTP implementation makes use of two algorithms:

#### HOTP - An HMAC-Based One-Time Password Algorithm
> "The document describes an algorithm to generate one-time password values, based on Hashed Message Authentication Code (HMAC). A security analysis of the algorithm is presented, and important parameters related to the secure deployment of the algorithm are discussed. The proposed algorithm can be used across a wide range of network applications ranging from remote Virtual Private Network (VPN) access, Wi-Fi network logon to transaction-oriented Web applications."
> -- <cite>[HMAC-Based One-Time Password Algorithm](https://tools.ietf.org/html/rfc4226)</cite>

---

#### TOTP draft 6 - Time-based One-time Password Algorithm

>"The document describes an extension of one-time password (OTP) algorithm, namely the HAMC-Based One-Time Password (HOTP) Algorithm as defined in RFC 4226, to support time-based moving factor. The HOTP algorithm specifies an event based OTP algorithm where the moving factor is an event counter. The present work bases the moving factor on a time value. A time-based variant of the OTP algorithm provides short-lived OTP values, which are desirable for enhanced security. The proposed algorithm can be used across a wide range of network applications ranging from remote Virtual Private Network (VPN) access, Wi-Fi network logon to transaction-oriented Web applications. The authors believe that a common and shared algorithm will facilitate adoption of two-factor authentication on the Internet by enabling interoperability across commercial and open-source implementations."
> -- <cite>[Time-based One-time Password Algorithm](https://tools.ietf.org/id/draft-mraihi-totp-timebased-06.html)</cite>
