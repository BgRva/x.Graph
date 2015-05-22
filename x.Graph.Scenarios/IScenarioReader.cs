using System;

namespace x.Graph.Scenarios
{
    public interface IScenarioReader : IDisposable
    {
        Scenario ReadFile(string fileName);
        Scenario ReadString(string scenarioString);
    }
}
