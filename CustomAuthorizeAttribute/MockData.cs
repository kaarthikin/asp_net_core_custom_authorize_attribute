// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using System.Collections.Generic;

namespace CustomAuthorizeAttribute
{
    public static class MockData
    {
        public static List<KeyValuePair<string, string>> UserPermissions;

        static MockData()
        {
            UserPermissions = new List<KeyValuePair<string, string>>();

            UserPermissions.Add(new KeyValuePair<string, string>("User1", "CanRead"));
            UserPermissions.Add(new KeyValuePair<string, string>("User1", "CanWrite"));
            UserPermissions.Add(new KeyValuePair<string, string>("User2", "CanRead"));
        }
    }
}
