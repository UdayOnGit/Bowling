# Bowling

A simple bowling score calculator, using the traditional scoring method specified
here: https://en.wikipedia.org/wiki/Ten-pin_bowling#Traditional_scoring.


## Getting started
**Get code**
> https://github.com/UdayOnGit/Bowling.git

Navigate to project folder, build, and run project
``` 
> cd Bowling/src
> dotnet build
> dotnet run
```

### API
``` 
endpoint: /api/scores
method: POST
```

### Examples

##Example 1
> POST https://localhost:5001/api/scores

###### HTTP request
```
POST /api/scores HTTP/1.1
Content-Type: application/json
User-Agent: PostmanRuntime/7.28.0
Accept: */*
Postman-Token: ea65672e-92ff-4bab-9d17-f3b9921c089e
Host: localhost:5001
Accept-Encoding: gzip, deflate, br
Connection: keep-alive
Content-Length: 69
 
{
"pinsDowned": [10, 10, 10, 10, 10,10, 10, 10, 10, 10, 10, 10]
}
```

###### HTTP response
```
{
    "frameProgressScores":["30","60","90","120","150","180","210","240","270","300"],
    "gameCompleted":true
}
```

##Example 2
> POST https://localhost:5001/api/scores

###### HTTP request
```
POST /api/scores HTTP/1.1
Content-Type: application/json
User-Agent: PostmanRuntime/7.28.0
Accept: */*
Postman-Token: ea65672e-92ff-4bab-9d17-f3b9921c089e
Host: localhost:5001
Accept-Encoding: gzip, deflate, br
Connection: keep-alive
Content-Length: 69
 
{
"pinsDowned": [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
}
```

###### HTTP response
```
{
    "frameProgressScores":["2","4","6","8","10","12","14","16"],
    "gameCompleted":false
}
```