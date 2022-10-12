/*
 * Copyright 2021 Automate The Planet Ltd.
 * Author: Teodor Nikolov
 * Licensed under the Apache License, Version 2.0 (the "License");
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package decorator.core;

import java.text.DecimalFormat;

public abstract class BaseAssertions<ElementsT extends BaseElements> {
    protected ElementsT elements() {
        return NewInstanceFactory.createByTypeParameter(getClass(), 0);
    }

    protected String formatCurrency(double number) {
        DecimalFormat currencyFormat = new DecimalFormat("#,##0.00\u20ac");
        currencyFormat.setMaximumFractionDigits(2);
        currencyFormat.setMinimumFractionDigits(2);
        return currencyFormat.format(number);
    }
}
