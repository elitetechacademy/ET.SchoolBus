using System;
using System.Text;
using ET.SchoolBus.Domain.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace ET.SchoolBus.Api.CustomAttributes;

public class PermissionAttribute : AuthorizeAttribute
{
    public PermissionAttribute(params Roles[] roles)
    {
        StringBuilder roleBuilder=new StringBuilder();
        foreach(var role in roles)
        {
            roleBuilder.Append($"{Enum.GetName(role)},");
        }
        var rolesString = roleBuilder.ToString();
        
        Roles = rolesString.Remove(roleBuilder.Length-1);
    }
}
