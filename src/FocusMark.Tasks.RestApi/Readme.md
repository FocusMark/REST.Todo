To get started you must first configure your environment to run with your JWT issuer. You will need to pull the issuer keys from the `.well-known` URL for your identity provider. For Cognito, this would be https://cognito-ido.{region}.amazonaws.com/{UserPoolId}/.well-known/jwks.json.

Take the key information from the `.well-known/jwks.json` document and adjust the configuration in `appsettings.json` to match.
```
 "Authorization": {
    "Issuers": [
      {
        "Url": "https://cognito-idp.{region}.amazonaws.com/{UserPoolId}",
        "DiscoveryDocument": "https://cognito-idp.{region}.amazonaws.com/{UserPoolId}/.well-known/jwks.json",
        "Keys": [
          {
            "alg": "RS256",
            "e": "AQAB",
            "kid": "",
            "kty": "RSA",
            "n": "",
            "use": "sig"
          },
          {
            "alg": "RS256",
            "e": "AQAB",
            "kid": "",
            "kty": "RSA",
            "n": "",
            "use": "sig"
          }
        ]
      }
    ]
  }
```