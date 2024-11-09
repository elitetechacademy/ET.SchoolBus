using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.CustomException;

public class NotFoundException : Exception
{
    public NotFoundException(string message):base(message)
    {
        
    }
}
