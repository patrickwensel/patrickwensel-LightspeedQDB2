namespace QBD2.Models
{
    public static class Enum
    {
        public enum DropDownType
        {
            FailureTypePrimary,
            FailureType,
            Station
        }

        public enum FileUploadType
        {
            Local,
            Azure,
        }

        public enum EnumMRBDispositions
        {
            Review = 1,
            Rework = 2,
            SendToVendor = 3,
            Scrap = 4,
            EngEval = 5,
            UseAsIs = 6
        }

        public enum RoleType
        {
            Admin = 1,
            User = 2,
            CanDeleteFailureCodes = 3,
            CanDeleteRepair = 4,
            WorkOrderAdmin = 5,
        }
    }
}
