#region dashCommerce License
/*

dashCommerce, and the dashCommerce logo are registered trademarks of Mettle Systems LLC. 
Mettle Systems LLC logos and trademarks may not be used without prior written consent.

The dashCommerce Store License:

The dashCommerce Store License covers the MettleSystems.dashCommerce.Store.dll and the 
MettleSystems.dashCommerce.Web.dll and the MettleSystems.dashCommerce.Content.dll and 
the files associated with the Store folder / project and the Web folder / project and the Content 
folder / project.
 
The dashCommerce Store License below applies to the dashCommerce software version 3.
 
Any version of the dashCommerce software prior to version 3 is not covered by this license. 
Please refer to the license document in such prior versions of the dashCommerce software to 
find the relevant license information.
 
Please note that regarding the dashCommerce Core the dashCommerce Core License applies.
 
Please also note that for the dashCommerce Store the dashCommerce Store Commercial License 
is also available.
 
The dashCommerce Store software is Copyright (c) 2007 - 2009 Mettle Systems LLC, 
P.O. Box 181192 Cleveland Heights, Ohio 44118, United States
 
Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
and associated documentation files (the "Software"), to deal in the Software, including the rights 
to use, copy, modify, merge, publish, distribute, sublicense, and / or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
The above copyright notice and this permission notice shall be included in all copies or substantial 
portions of the Software. To the extent the Software contains the dashCommerce name, trademark, 
brand and / or the dashCommerce logo, any copy, modification, merger, publication, distribution 
or equivalent use of the Software shall retain any such names, trademarks, brand and / or logos 
intact and plainly visible and plainly legible.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESSED OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGE OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Any non-compliance with this license agreement is to be considered a full and unconditional agreement 
of the dashCommerce Store Commercial License.
 
Any dispute which may arise between the parties, concerning this license and / or use of the software, 
is to be brought before the United States Courts in the State of Ohio at the venue of Mettle Systems LLC. 
This license shall be governed and construed in accordance with the laws of the United States.

The dashCommerce Core (MIT License):
 
The dashCommerce Core (MIT License) covers the MettleSystems.dashCommerce.Core.dll the 
MettleSystems.dashCommerce.Localization.dll, and the MettleSystems.dashCommerce.Controls.dll 
and the files associated with the Core folder / project, the Localization folder / project, and the Controls 
folder / project.
 
The dashCommerce Core software is Copyright (c) 2007 - 2009 Mettle Systems LLC, 
P.O. Box 181192 Cleveland Heights, Ohio 44118, United States
 
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and / or sell copies of the Software, and to permit persons to whom the Software is furnished to do 
so, subject to the following conditions:
 
The above copyright notice and this permission notice shall be included in all copies or substantial 
portions of the Software.
 
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE 
USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

using System.Collections;
using System.Web.Caching;

namespace MettleSystems.Framework.Core.Caching.Providers {

  public interface ICacheProvider {

    /// <summary>
    /// Gets the <see cref="System.Object"/> with the specified key.
    /// </summary>
    /// <value></value>
    object this[string key] {
      get;
    }

    /// <summary>
    /// Gets the specified item key.
    /// </summary>
    /// <param name="itemKey">The item key.</param>
    /// <returns></returns>
    object Get(string itemKey);

    /// <summary>
    /// Clears the cache.
    /// </summary>
    void ClearCache();

    /// <summary>
    /// Removes the specified item key.
    /// </summary>
    /// <param name="itemKey">The item key.</param>
    void Remove(string itemKey);

    /// <summary>
    /// Inserts the specified value into the cache with the keyString as its Key.
    /// </summary>
    /// <param name="keyString">The key string.</param>
    /// <param name="value">The value.</param>
    /// <param name="cacheDurationInSeconds">The cache duration in seconds.</param>
    /// <param name="priority">The priority.</param>
    void Insert(string keyString, object value, int cacheDurationInSeconds, CacheItemPriority priority);

    /// <summary>
    /// Gets the enumerator.
    /// </summary>
    /// <returns></returns>
    IDictionaryEnumerator GetEnumerator();

    /// <summary>
    /// Gets the amount of items in the cache.
    /// </summary>
    /// <returns></returns>
    int GetCount();

  }
}