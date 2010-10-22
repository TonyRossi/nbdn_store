using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class EnumerableExtensionsSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(EnumerableExtensions))]
        public class when_processing_each_element_in_a_data_structure_with_a_visitor : concern
        {
            Establish c = () =>
            {
                all_items = new List<ItemToVisit>();
                IterationExtensions.each(Enumerable.Range(1,100),x => all_items.Add(an<ItemToVisit>()));
            };

            Because b = () =>
                EnumerableExtensions.each(all_items, x => x.visit());

            It should_visit_each_item_with_a_visitor = () =>
                IterationExtensions.each(all_items, x => x.received(y => y.visit()));

            static IList<ItemToVisit> all_items;
        }

        public class ItemToVisit
        {
            public virtual void visit()
            {
            }
        }
    }
}