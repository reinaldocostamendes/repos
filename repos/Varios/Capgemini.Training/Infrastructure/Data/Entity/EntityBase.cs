using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capgemini.Infrastructure.Data.Entity
{
    public abstract class EntityBase<TEntity>
    {
        public Guid Id { get; set; }

        #region Validation

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();

        #endregion Validation
    }
}