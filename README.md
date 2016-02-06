Welcome to OEliteApiClient
===================


Hey! I'm your first Markdown document in **StackEdit**[^stackedit]. Don't delete me, I'm very helpful! I can be recovered anyway in the **Utils** tab of the <i class="icon-cog"></i> **Settings** dialog.

----------


Usage
-------------

StackEdit stores your documents in your browser, which means all your documents are automatically saved locally and are accessible **offline!**

> **Note:**

> - StackEdit is accessible offline after the application has been loaded for the first time.
> - Your local documents are not shared between different browsers or computers.
> - Clearing your browser's data may **delete all your local documents!** Make sure your documents are synchronized with **Google Drive** or **Dropbox** (check out the [<i class="icon-refresh"></i> Synchronization](#synchronization) section).

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

