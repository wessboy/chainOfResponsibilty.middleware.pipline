using chainOfResponsibilty.pipline.Domaine.Services;


namespace chainOfResponsibilty.pipline.Application;

     public class MachineManager : IMachineManager
    {
        private readonly Dictionary<string, bool> _machines;
        public MachineManager()
        {
          _machines = new Dictionary<string, bool>()
            {
                {"M1",true},
                {"M2",false},
                {"M3",false}
            };
        
        }

    public bool Activate(string machineName)
    {
        if(_machines.ContainsKey(machineName) &&  !_machines[machineName]) 
        {
            _machines[machineName] = true;
            return true;
        }

        return false;
    }
    
}

