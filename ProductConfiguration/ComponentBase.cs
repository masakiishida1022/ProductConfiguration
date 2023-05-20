using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public abstract class ComponentBase
    {
        public EtherCableModel EtherCable { get; }
        public ComponentSpecifier Specifier { get; }

        protected Dictionary<ComponentType, List<ComponentSpecifier>> relatedComponent =
            new Dictionary<ComponentType, List<ComponentSpecifier>>();

        public List<ProductItemModel> Options { get; } = new List<ProductItemModel>();

        public ComponentBase(ComponentSpecifier specfier, EtherCableModel eatherCable, List<ProductItemModel> options)
        {
            this.Specifier = specfier;
            this.EtherCable = eatherCable;
            if (options != null)
            {
                this.Options.AddRange(options);
            }
        }

        public List<ComponentSpecifier> GetRelatedComponent(ComponentType type)
        {
            var results = new List<ComponentSpecifier>();
            if (relatedComponent.ContainsKey(type))
            {
                results.AddRange(relatedComponent[type]);
            }

            return results;
        }

        public void AddRelatedComponent(ComponentSpecifier specifier)
        {
            if (!relatedComponent.ContainsKey(specifier.Type))
            {
                relatedComponent.Add(specifier.Type, new List<ComponentSpecifier>());
            }

            relatedComponent[specifier.Type].Add(specifier);
        }

        public static IEnumerable<T> GetRelatedComponents<T>(List<T> componentList, ComponentType type, int index) where T : ComponentBase 
        {
            foreach (var component in componentList)
            {
                var specifier = component.GetRelatedComponent(type) ?.FirstOrDefault();
                if (specifier != null && specifier.Index == index)
                {
                    yield return component;
                }
            }
        }

        public IEnumerable<ProductItemModel> GetProductItemModels()
        {
            yield return this.Specifier.Model;

            if (this.EtherCable != null)
            {
                yield return this.EtherCable;
            }

            foreach (var product in this.Options)
            {
                yield return product;
            }

            foreach (var product in OnGetProductItemModels())
            {
                yield return product;
            }
        }

        public double GetConsumedPower()
        {
            return 100; //Specifier.Model;
        }
        protected abstract IEnumerable<ProductItemModel> OnGetProductItemModels();

    }
}
