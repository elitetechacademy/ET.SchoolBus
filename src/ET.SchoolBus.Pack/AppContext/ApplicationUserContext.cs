using System;
using System.Security.Claims;

namespace ET.SchoolBus.Pack.AppContext;

public class ApplicationUserContext
{
    public ClaimsPrincipal CurrentUser { get; set; }

    public string Username 
    { 
        get
        {
            return CurrentUser.Claims
                .FirstOrDefault(x =>x.Type == ClaimTypes.Name)?.Value;
        }
    }
    public string Role 
    { 
        get
        {
            return CurrentUser.Claims
                .FirstOrDefault(x =>x.Type == ClaimTypes.Role)?.Value;        
        }    
    }
    public string Email 
    { 
        get
        {
            return CurrentUser.Claims
                .FirstOrDefault(x =>x.Type == ClaimTypes.Email)?.Value;        
        }    
    }

    public int? UserId 
    { 
        get
        {
            int userId;
            var userIdResult = int.TryParse(CurrentUser.Claims.FirstOrDefault(x =>x.Type == ClaimTypes.NameIdentifier)?.Value, out userId);
            if(userIdResult)
                return userId;
            return null;                  
        }    
    }
}
