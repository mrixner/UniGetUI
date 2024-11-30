using System.Runtime.InteropServices;
using UniGetUI.PackageEngine.Enums;
using UniGetUI.PackageEngine.Serializable;

namespace UniGetUI.PackageEngine.Interfaces
{
    public interface IInstallationOptions
    {
        public bool SkipHashCheck { get; set; }
        public bool InteractiveInstallation { get; set; }
        public bool RunAsAdministrator { get; set; }
        public string Version { get; set; }
        public Architecture? Architecture { get; set; }
        public PackageScope? InstallationScope { get; set; }
        public List<string> CustomParameters { get; set; }
        public bool RemoveDataOnUninstall { get; set; }
        public bool PreRelease { get; set; }
        public string CustomInstallLocation { get; set; }
        public Dictionary<string, string> CustomEnvironmentVariables { get; set; }
        public IPackage Package { get; }

        /// <summary>
        /// Loads and applies the options from the given SerializableInstallationOptions_v1 object to the current object.
        /// </summary>
        public void FromSerializable(SerializableInstallationOptions_v1 options);

        /// <summary>
        /// Returns a SerializableInstallationOptions_v1 object containing the options of the current instance.
        /// </summary>
        public SerializableInstallationOptions_v1 AsSerializable();

        /// <summary>
        /// Saves the current options to disk, asynchronously.
        /// </summary>
        public async Task SaveToDiskAsync()
        {
            await Task.Run(() => SaveToDisk());
        }

        /// <summary>
        /// Loads the options from disk, asynchronously.
        /// </summary>
        public async Task LoadFromDiskAsync()
        {
            await Task.Run(() => LoadFromDisk());
        }

        /// <summary>
        /// Saves the current options to disk.
        /// </summary>
        public void SaveToDisk();

        /// <summary>
        /// Loads the options from disk.
        /// </summary>
        protected void LoadFromDisk();

        /// <summary>
        /// Returns a string representation of the current options.
        /// </summary>
        public string ToString();
    }
}
