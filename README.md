### Custom Authorize Attribute in Asp. Net Core 2.2/3.0 and above

The authorize attribute is used to authorize or control user access to application/controller/actions in Asp. Net Core. The built in **[Authorize]** attribute might not be suitable for all business cases where we must come up with our own implementation. 

The code here has implements custom authorization in two different approaches.
1. Extending **AuthorizeAttribute** along with **IAuthorizationFilter**
2. **Creating Custom Authorization Policy Provider** with Authorization Handler, Authorization Requirement and an Authorize Attribute

The explination for approaches can be found in the link given below

Approach 1 : [https://www.craftedforeveryone.com/adding-your-own-custom-authorize-attribute-to-asp-net-core-2-2-and-above/](https://www.craftedforeveryone.com/adding-your-own-custom-authorize-attribute-to-asp-net-core-2-2-and-above/ "https://www.craftedforeveryone.com/adding-your-own-custom-authorize-attribute-to-asp-net-core-2-2-and-above/")

Approach 2 : [https://www.craftedforeveryone.com/custom-authorization-policy-provider-with-custom-authorize-attribute-in-asp-net-core-2-2-and-above/](https://www.craftedforeveryone.com/custom-authorization-policy-provider-with-custom-authorize-attribute-in-asp-net-core-2-2-and-above/ "https://www.craftedforeveryone.com/custom-authorization-policy-provider-with-custom-authorize-attribute-in-asp-net-core-2-2-and-above/")

Permission based authorization is used as an example here and permissions are mainted as KeyValuePairs within the code.

The attribute usage for both the approaches at controller or action level will be as below

**Approach 1 Usage:**
```csharp
[A1AuthorizePermission(Permissions = "CanRead")]
[HttpGet("{id}")]
public ActionResult<string> Get(int id)
{
    return "value";
}
```
**Approach 2 Usage**
```csharp
[A2AuthorizePermission(Permissions = "CanRead")]
[HttpGet("{id}")]
public ActionResult<string> Get(int id)
{
    return "value";
}
```
