using JetBrains.Annotations;
using Json.Schema.Generation;

namespace Nox
{

    [Title("Specifies information on storing and retrieving the entity")]
    [Description("Provides hints to the database engine and API as to how this entity should be managed in the persistence store.")]
    [AdditionalProperties(false)]
    public class EntityPersistence : DefinitionBase
    {

        [Title("Whether all changes to this entity is tracked fo versioning and auditing.")]
        [Description("Indicates to the storage engine that all changes to this entity must be tracked over time. Usually used to time-travel, track or audit an entity's state changes.")]
        public bool IsVersioned { get; set; } = true;

        public string? TableName { get; set; }

        public string Schema { get; set; } = "dbo";

        public EntityCreateSettings Create { get; set; } = new EntityCreateSettings();
        public EntityReadSettings Read { get; set; } = new EntityReadSettings();
        public EntityUpdateSettings Update { get; set; } = new EntityUpdateSettings();
        public EntityDeleteSettings Delete { get; set; } = new EntityDeleteSettings();
        
        internal bool ApplyDefaults(string entityName)
        {
            if (string.IsNullOrWhiteSpace(TableName)) TableName = entityName;
            if (string.IsNullOrWhiteSpace(Schema)) Schema = "dbo";
            return true;
        }
    }

    public class EntityCreateSettings
    {
        public bool IsEnabled { get; set; } = true;
        public bool RaiseEvents { get; set; } = true;
    }

    public class EntityReadSettings
    {
        public bool IsEnabled { get; set; } = true;
    }

    public class EntityUpdateSettings
    {
        public bool IsEnabled { get; set; } = true;
        public bool RaiseEvents { get; set; } = true;
    }

    public class EntityDeleteSettings
    {
        public bool IsEnabled { get; set; } = true;
        public bool RaiseEvents { get; set; } = true;
        public bool UseSoftDelete { get; set; } = true;
    }
   

}