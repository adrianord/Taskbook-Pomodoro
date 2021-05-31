using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TaskBookPomo.Bootstrap.Helpers
{
    public static class AssemblyScanning
    {
        public static Assembly[] GetAssemblies(Type? entryType = null)
        {
            var checkedAssemblies = new HashSet<Assembly>();
            var entryAssembly = entryType?.Assembly ?? Assembly.GetEntryAssembly()!;
            var entryAssemblyFirstPrefix = entryAssembly.GetName().Name!.Split(separator: ".").First();
            var toCheck = new Queue<Assembly>(collection: new[] {entryAssembly});

            while (toCheck.Count > 0)
            {
                var assembly = toCheck.Dequeue();
                checkedAssemblies.Add(item: assembly);

                var loaded = assembly.GetReferencedAssemblies()
                                     .Where(predicate: x => x.Name?.StartsWith(value: entryAssemblyFirstPrefix) ?? false)
                                     .Where(predicate: x => !checkedAssemblies.Any(predicate: chx => AssemblyName.ReferenceMatchesDefinition(reference: x, definition: chx.GetName())))
                                     .Where(predicate: x => !toCheck.Any(predicate: chx => AssemblyName.ReferenceMatchesDefinition(reference: x, definition: chx.GetName())))
                                     .Select(selector: Assembly.Load);
                foreach (var loadedAssembly in loaded)
                {
                    toCheck.Enqueue(item: loadedAssembly);
                }
            }

            var allReferencedAssemblies = checkedAssemblies.ToArray();
            if (allReferencedAssemblies.Length == 0) throw new InvalidOperationException(message: "Entry Assembly not loaded properly");
            return allReferencedAssemblies;
        }
    }
}