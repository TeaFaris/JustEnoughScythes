using System;
using System.Collections.Generic;
using System.Linq;

namespace JustEnoughSickles.Utils
{
    public class Switch<T>
    {
        protected readonly T Value;
        protected bool DidAction { get; set; } = false;
        public Switch(T Value) => this.Value = Value;
        public virtual Switch<T> Case(Predicate<T> Predicate, Action Action)
        {
            if (Predicate(Value))
            {
                Action();
                DidAction = true;
            }
            return this;
        }
        public virtual Switch<T> Case(T Value, Action Action) => Case(x => x.Equals(Value), Action);
        public virtual Switch<T> Case(IEnumerable<T> Values, Action Action) => Case(x => Values.Any(y => y.Equals(x)), Action);
        public virtual void Default(Action Action)
        {
            if (!DidAction) Action();
        }
    }
}
