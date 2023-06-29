namespace EntityFrameworkDemo.Global
{
    public static class Constants
    {
        #region AutoMapper
        public static string ErrorMappingToDevice = $"Error Mapping from Device Entity to Device Dto";
        public static string ErrorMappingToSubSystem = $"Error Mapping from SubSystem Entity to SubSystem Dto";
        public static string ErrorMappingToUser = $"Error Mapping from User Entity to User Dto";
        #endregion

        #region Validations
        public static string DeviceAlreadyExistsWithinSystem = "{PropertyName}, {PropertyValue} already exists within the SubSystem.";
        public static string SubSystemAlreadyExists = "{PropertyName}, {PropertyValue} already exists in the SubSystem Table.";
        public static string UserNameAlreadyExists = "{PropertyName}, {PropertyValue} already exists in the User Table.";
        #endregion
    }
}
