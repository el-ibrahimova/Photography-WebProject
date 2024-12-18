﻿namespace Photography.Core.ViewModels.PhotoShoot
{
    public class AllPhotoShootsViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl1 { get; set; } = null!;
        public string? ImageUrl2 { get; set;} 
        public string? ImageUrl3 { get; set;}
        public string PhotographerBrandName { get; set; } = null!;
        public string PhotographerId { get; set; } = null!;
        public ICollection<ParticipantViewModel> Participants { get; set; } = new HashSet<ParticipantViewModel>();
    }
}
