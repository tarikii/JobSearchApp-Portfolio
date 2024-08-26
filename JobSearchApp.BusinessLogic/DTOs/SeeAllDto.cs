using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchApp.BusinessLogic.DTOs
{
    public class SeeAllDto
    {
        public IEnumerable<UserSkillDto> UserSkills { get; set; }
        public IEnumerable<InterestDto> UserInterests { get; set; }
        public IEnumerable<UserPreferenceDto> UserPreferences { get; set; }
    }
}
