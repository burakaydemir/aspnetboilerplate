﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Abp.Notifications
{
    /// <summary>
    /// Used to store published/sent notification.
    /// </summary>
    [Serializable]
    [Table("AbpNotifications")]
    public class NotificationInfo : CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// Maximum length of <see cref="NotificationName"/> property.
        /// </summary>
        public const int MaxNotificationNameLength = 128;

        /// <summary>
        /// Maximum length of <see cref="Data"/> property.
        /// Value: 1048576 (1 MB).
        /// </summary>
        public const int MaxDataLength = 1024 * 1024;

        /// <summary>
        /// Maximum lenght of <see cref="DataTypeName"/> property.
        /// Value: 512.
        /// </summary>
        public const int MaxDataTypeNameLength = 512;

        /// <summary>
        /// Maximum lenght of <see cref="EntityTypeName"/> property.
        /// Value: 512.
        /// </summary>
        public const int MaxEntityTypeNameLength = 256;

        /// <summary>
        /// Maximum lenght of <see cref="EntityTypeAssemblyQualifiedName"/> property.
        /// Value: 512.
        /// </summary>
        public const int MaxEntityTypeAssemblyQualifiedNameLength = 512;

        /// <summary>
        /// Maximum lenght of <see cref="EntityId"/> property.
        /// Value: 256.
        /// </summary>
        public const int MaxEntityIdLength = 128;

        /// <summary>
        /// Maximum lenght of <see cref="UserIds"/> property.
        /// Value: 131072 (128 KB).
        /// </summary>
        public const int MaxUserIdsLength = 128 * 1024;

        /// <summary>
        /// Unique notification name.
        /// </summary>
        [Required]
        [MaxLength(MaxNotificationNameLength)]
        public virtual string NotificationName { get; set; }

        /// <summary>
        /// Notification data as JSON string.
        /// </summary>
        [MaxLength(MaxDataLength)]
        public virtual string Data { get; set; }

        /// <summary>
        /// Type of the JSON serialized <see cref="Data"/>.
        /// It's AssemblyQualifiedName of the type.
        /// </summary>
        [MaxLength(MaxDataTypeNameLength)]
        public virtual string DataTypeName { get; set; }

        /// <summary>
        /// Gets/sets entity type name, if this is an entity level notification.
        /// It's FullName of the entity type.
        /// </summary>
        [MaxLength(MaxEntityTypeNameLength)]
        public virtual string EntityTypeName { get; set; }

        /// <summary>
        /// AssemblyQualifiedName of the entity type.
        /// </summary>
        [MaxLength(MaxEntityTypeAssemblyQualifiedNameLength)]
        public virtual string EntityTypeAssemblyQualifiedName { get; set; }

        /// <summary>
        /// Gets/sets primary key of the entity, if this is an entity level notification.
        /// </summary>
        [MaxLength(MaxEntityIdLength)]
        public virtual string EntityId { get; set; }

        /// <summary>
        /// Notification severity.
        /// </summary>
        public virtual NotificationSeverity Severity { get; set; }

        /// <summary>
        /// Target users of the notification.
        /// If this is set, it overrides subscribed users.
        /// If this is null/empty, then notification is sent to all subscribed users.
        /// </summary>
        [MaxLength(MaxUserIdsLength)]
        public virtual string UserIds { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationInfo"/> class.
        /// </summary>
        public NotificationInfo()
        {
            Severity = NotificationSeverity.Info;
        }
    }
}