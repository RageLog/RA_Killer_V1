//regex
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace RA_Killer_V1
{

    using contextList = List<cMailLabel>;
    struct cMailLabel
    {
        public string name;
        public string value;
    }
    class cMailLabels : contextList
    {
        public contextList getLabelAndValueList(string text) {

            
            Regex _mRegex = new Regex(@"(?<Type>(?<=#)\w+(?=:\w+)):(?<Context>(?<=:)\w+)");//
            var _mMaches = _mRegex.Matches(text);

            if (_mMaches.Count > 0)
            {
                foreach (Match item in _mMaches)
                {
                    cMailLabel _mLabel;
                    _mLabel.name = item.Groups["Type"].Value;
                    _mLabel.value = item.Groups["Context"].Value;
                    this.Add(_mLabel);
                }
                
            }
            return this;
        }   
    }
}
