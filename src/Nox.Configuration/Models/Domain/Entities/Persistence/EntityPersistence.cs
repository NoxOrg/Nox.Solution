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
        public bool IsVersioned { get; internal set; } = true;

        public string? TableName { get; internal set; }

        public string Schema { get; internal set; } = "dbo";

        public EntityCreateSettings Create { get; internal set; } = new EntityCreateSettings();
        public EntityReadSettings Read { get; internal set; } = new EntityReadSettings();
        public EntityUpdateSettings Update { get; internal set; } = new EntityUpdateSettings();
        public EntityDeleteSettings Delete { get; internal set; } = new EntityDeleteSettings();
        
        internal bool ApplyDefaults(string entityName)
        {
            if (string.IsNullOrWhiteSpace(TableName)) TableName = entityName;
            if (string.IsNullOrWhiteSpace(Schema)) Schema = "dbo";
            return true;
        }
    }

    public class EntityCreateSettings
    {
        public bool IsEnabled { get; internal set; } = true;
        public bool RaiseEvents { get; internal set; } = true;
    }

    public class EntityReadSettings
    {
        public bool IsEnabled { get; internal set; } = true;
    }

    public class EntityUpdateSettings
    {
        public bool IsEnabled { get; internal set; } = true;
        public bool RaiseEvents { get; internal set; } = true;
    }

    public class EntityDeleteSettings
    {
        public bool IsEnabled { get; internal set; } = true;
        public bool RaiseEvents { get; internal set; } = true;
        public bool UseSoftDelete { get; internal set; } = true;
    }
   

}