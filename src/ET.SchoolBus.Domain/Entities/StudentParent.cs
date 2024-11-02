using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class StudentParent : BaseEntity
{
    public int StudentId { get; set; } //Foreign Key
    public int ParentId { get; set; } //Foreign Key

    public Student Student { get; set; }
    public Parent Parent { get; set; }
}
