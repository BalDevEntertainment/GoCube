using System;

namespace GoCube.Presentation.ExperienceUi
{
    public interface IExperienceUi
    {
        event Action OnUiLoaded;
        void UpdateExperienceBar(ExperienceViewModel experienceViewModel);
        void FillExperienceBar(ExperienceViewModel newExperienceViewModel);
    }
}