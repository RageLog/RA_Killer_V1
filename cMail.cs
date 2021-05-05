//Outlook
using NetOffice;
using OutLook = NetOffice.OutlookApi;

namespace RA_Killer_V1
{
    class cMail : OutLook.MailItem
    {
        public cMail(ICOMObject replacedObject) : base(replacedObject)
        {
            
        }

        private eMailType _mType { get; set; }
        public eMailType getMailType() => this._mType;
        public cMailLabels getMailsLabels() 
        {
            cMailLabels _mLabels = new cMailLabels();
            _mLabels.AddRange(getMailsLabelsFromBody());
            _mLabels.AddRange(getMailsLabelsFromSubject());
            return _mLabels;
        }
        private cMailLabels getMailsLabelsFromBody()
        {
            cMailLabels _mLabels = new cMailLabels();
            return (cMailLabels)_mLabels.getLabelAndValueList(this.Body);
        }
        private cMailLabels getMailsLabelsFromSubject()
        {
            cMailLabels _mLabels = new cMailLabels();
            return (cMailLabels)_mLabels.getLabelAndValueList(this.Subject);
        }
        public void setReaded() => this.UnRead = false;
        public void setUnReaded() => this.UnRead = true;
        public void Classification()
        {
            foreach (var item in getMailsLabels())
            {
                if (item.name.Equals("TYPE"))
                {
                    switch (item.value)
                    {
                        case "TSS":
                            _mType = eMailType.TSS;
                            return;
                        case "SVT":
                            _mType = eMailType.SVT;
                            return;
                        case "PO":
                            _mType = eMailType.SVT;
                            return;
                    }
                }
            }
            _mType = eMailType.NA;
        }
    }
}
