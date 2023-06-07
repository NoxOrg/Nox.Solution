using System;
using System.Linq;

namespace Nox
{

    public enum EntityRelationshipType
    {
        ZeroOrOne,
        ExactlyOne,
        ZeroOrMany,
        OneOrMany
    }

    public static class EntityRelationshipTypeHelpers
    {
        public static string NameList()
        {
            var list = Enum.GetValues(typeof(EntityRelationshipType))
                .Cast<EntityRelationshipType>()
                .ToList();
            return string.Join(", ", list);
        }
    }
}