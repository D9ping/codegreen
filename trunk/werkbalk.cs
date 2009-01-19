using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGreen
{
    class werkbalk
    {
    public enum WerkbalkState
    {
        INSTRUCTIE,
        INVENTORY,
        BANK,        
        HUIS
    } 
            #region datavelden
            WerkbalkState werkbalk;

            #endregion

            #region constructor
            #endregion

            #region properties
            public WerkbalkState Toestand
            {
                get { return werkbalk; }
            }
            #endregion

            #region methoden


            public void toon()
            {
            switch (werkbalk)
            {
                case WerkbalkState.INSTRUCTIE:
                    ToonGB(gbxGameInstructions);
                    tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");

                    tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");

                    tooltip.SetToolTip(this.pbKnopshop, "go to shop");
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_on.png");

                    break;
                case WerkbalkState.INVENTORY:
                    ToonGB(gbxInventory);
                    tooltip.SetToolTip(this.pbKnopInventory, "close inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_on.png");

                    tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");

                    tooltip.SetToolTip(this.pbKnopshop, "go to shop");
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png");
                    break;
                case WerkbalkState.BANK:
                    ToonGB(gbxBank);
                    tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");

                    tooltip.SetToolTip(this.pbKnopBank, "logout bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_on.png");

                    tooltip.SetToolTip(this.pbKnopshop, "go to shop");
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png");
                    break;
                case WerkbalkState.HUIS:
                    ToonGB(gbxInformatieHuis);
                    tooltip.SetToolTip(this.pbKnopInventory, "open inventory");
                    pbKnopInventory.Image = resourcehandler.loadimage("werkbalkknop_inventory_off.png");

                    tooltip.SetToolTip(this.pbKnopBank, "login bank");
                    pbKnopBank.Image = resourcehandler.loadimage("werkbalkknop_bank_off.png");

                    tooltip.SetToolTip(this.pbKnopshop, "go to shop");
                    pbKnopshop.Image = resourcehandler.loadimage("werkbalkknop_shop_off.png");
                    break;
            }

            }
        #endregion
        }
    }
}
