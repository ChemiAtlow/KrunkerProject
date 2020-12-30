using Krunker.Common.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace Krunker.Server.ModelBinders
{
    public class ShoppingItemModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(ShoppingItem))
            {
                return null;
            }

            var subclasses = new[] { typeof(BackItem), typeof(HeadItem), typeof(PrimaryWeapon), typeof(SecondaryWeapon),  };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new ShoppingItemModelBinder(binders);
        }
    }
}
