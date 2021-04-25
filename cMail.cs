//Outlook
using OutLook = NetOffice.OutlookApi;

namespace RA_Killer_V1
{
    class cMail : OutLook.MailItem
    {
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
    }
}
