using System;
using System.Collections.Generic;
using System.Text;

namespace design_patterns_with_csharp
{
    public interface IComponent<T>
    {
        void Add(IComponent<T> c);
        IComponent<T> Remove(T s);
        string Display(int depth);
        IComponent<T> Find(T s);
        T Name { get; set; }
    }

    public class Component<T> : IComponent<T>
    {
        public T Name { get; set; }

        public Component(T name)
        {
            Name = name;
        }

        public void Add(IComponent<T> c)
        {
            Console.WriteLine("Cannot add to an item");
        }

        public IComponent<T> Remove(T s)
        {
            Console.WriteLine("Cannot remove directly");
            return this;
        }

        public string Display(int depth)
        {
            return new String('-', depth) + Name + "\n";
        }

        public IComponent<T> Find(T s)
        {
            if (s.Equals(Name))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public class Composite<T> : IComponent<T>
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            readonly List<IComponent<T>> list;
            
            public T Name { get; set; }
            
            public Composite(T name)
            {
                Name = name;
                list = new List<IComponent<T>>();
            }
            
            public void Add(IComponent<T> c)
            {
                list.Add(c);
            }

            IComponent<T> holder = null;

            /// <summary>
            /// Finds the item from a particular point in the structure
            /// and returns the composite from which it was removed
            /// If not found, return the point as given
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public IComponent<T> Remove(T s)
            {
                holder = this;
                IComponent<T> p = holder.Find(s);
                if (holder != null)
                {
                    (holder as Composite<T>).list.Remove(p);
                    return holder;
                }
                else
                {
                    return this;
                }
            }

            /// <summary>
            /// Recursively looks for an item
            /// Returns its reference or else null
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public IComponent<T> Find(T s)
            {
                holder = this;
                if (Name.Equals(s))
                {
                    return this;
                }

                IComponent<T> found = null;
                foreach (IComponent<T> c in list)
                {
                    found = c.Find(s);
                    if (found != null)
                    {
                        break;
                    }
                }
                return found;
            }

            /// <summary>
            /// Display items in a format indicating their level in the composite structure
            /// </summary>
            /// <param name="depth"></param>
            /// <returns></returns>
            public string Display(int depth)
            {
                StringBuilder s = new StringBuilder(new string('-', depth));
                s.Append("Set " + Name + " length :" + list.Count + "\n");
                foreach (IComponent<T> component in list)
                {
                    s.Append(component.Display(depth + 2));
                }
                return s.ToString();
            }
        }
    }
}
