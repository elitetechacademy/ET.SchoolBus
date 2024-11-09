using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Domain.Repositories;

namespace ET.SchoolBus.Data.Repositories;

public class ModelRepository : GenericRepository<Model>, IModelRepository
{
    private readonly SchoolBusContext _schoolBusContext;

    public ModelRepository(SchoolBusContext schoolBusContext) : base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }
}
