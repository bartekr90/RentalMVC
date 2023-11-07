using AutoMapper;
using RentalMVC.Application.Mapping.Mapping;
using System.Reflection;

namespace RentalMVC.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        List<Type> types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any( i =>
            i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();
        
        foreach (var type in types)
        {
            object? instance = Activator.CreateInstance(type);
            MethodInfo? methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
