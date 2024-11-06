using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;
 
public class Parent : BaseEntity, ITenantEntity
{
    public int ParentId { get; set; } //Primary Key
    public int ProfessionId { get; set; } //Foreign Key
    public int SchoolId { get; set; } //Foreign Key
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    public Profession Profession { get; set; }
    public School School { get; set; }
    public ICollection<StudentParent> StudentParents { get; set; }
}
