namespace PetitionManagementSystem.Models
{
    public class PentitionPetitionHandler
    {
        public int PentitionPetitionHandlerId { get; set; }
        public Petition Petition { get; set; }
        public PetitionHandler PetitionHandler { get; set; }
    }
}
