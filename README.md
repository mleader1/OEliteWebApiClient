Welcome to OEliteApiClient
===================

OEliteWebApiClient is a simple HTTPClient wrapper; Feel free to use it in your project or simply just for study purpose.

**For .NET Core version, please visit https://github.com/oelite/RESTme **

----------


Usage
-------------


> **Note:**


#### <i class="icon-file"></i> GET

```
var result = await client.GetJsonAsync<CalcResult>("/api/Calc",
         new KeyValuePair<string, string>("param1", param1),
         new KeyValuePair<string, string>("param2", param2));

var result = await client.GetAsync<CalcResult>(string.Format("/api/Calc/{0}/{1}", param1, param2));

```

#### <i class="icon-file"></i> POST


```
var result = await client.PostAsync<CalcRequest, CalcResult>("/api/Calc", new CalcRequest() { Param1 = param1, Param2 = param2 });

var result = await client.PostJsonAsync<CalcResult>("/api/Calc/form",
         new KeyValuePair<string, string>("param1", param1),
         new KeyValuePair<string, string>("param2", param2));
```
#### <i class="icon-file"></i> PUT

```
var result = await client.PutAsync<CalcRequest, CalcResult>("/api/Calc", new CalcRequest() { Param1 = param1, Param2 = param2 });

var result = await client.PutJsonAsync<CalcResult>("/api/Calc/form",
         new KeyValuePair<string, string>("param1", param1),
         new KeyValuePair<string, string>("param2", param2));

var result = await client.DeleteJsonAsync<CalcResult>("/api/Calc",
         new KeyValuePair<string, string>("param1", param1),
         new KeyValuePair<string, string>("param2", param2));
```
#### <i class="icon-file"></i> DELETE

``` 
var result = await client.DeleteAsync<CalcResult>(string.Format("/api/Calc/{0}/{1}", param1, param2));
```





> **NOTE:** This is a piece of code leveraged from our OElite project and released here as open source free code. OEliteWebApiClient is a simple HTTPClient wrapper, but hopefully it can help your coding productivity as well. Cheers.

----------

