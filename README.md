# UnityRest
Unity Rest Library that uses promises

```c#
var client = gameObject.AddComponent<Client>();

// GET request
Request request = new Request("http://httpbin.org/get", Method.GET);
client.Execute(request).Done(result => {
  Debug.Log(result.data);
});

// POST request
Request request = new Request("http://httpbin.org/post", Method.POST);
request.AddParameter("param1", "test");
client.Execute(request).Done(result => {
  Debug.Log(result.data);
});
```
