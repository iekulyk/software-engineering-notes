Authentication types
---

 A web client can authenticate a user to a web server using one of the following mechanisms:

  -  HTTP Basic Authentication

  -  HTTP Digest Authentication

  -  HTTPS Client Authentication

  - Form Based Authentication 
  
**HTTP Basic Authentication**

---

HTTP Basic Authentication, which is based on a username and password, is the authentication mechanism defined in the HTTP/1.0 specification. A web server requests a web client to authenticate the user. As part of the request, the web server passes the realm (a string) in which the user is to be authenticated. The realm string of Basic Authentication does not have to reflect any particular security policy domain (confusingly also referred to as a realm). The web client obtains the username and the password from the user and transmits them to the web server. The web server then authenticates the user in the specified realm.

Basic Authentication is not a secure authentication protocol. User passwords are sent in simple base64 ENCODING (not ENCRYPTED !), and the target server is not authenticated. Additional protection can alleviate some of these concerns: a secure transport mechanism (HTTPS), or security at the network level (such as the IPSEC protocol or VPN strategies) is applied in some deployment scenarios. 

**HTTP Digest Authentication**

