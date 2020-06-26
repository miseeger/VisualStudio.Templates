import { Component } from '@angular/core';
import { FieldType } from '@ngx-formly/core';

@Component({
    // tslint:disable-next-line: component-selector
    selector: 'prime-multi-select',
    template: `
        <div>
            <label style="display:block;width:100%;"
                >{{ to.label || '' }}{{ to.description || '' }}</label
            >
            <p-multiSelect [options]="to.options" [formControl]="formControl">
            </p-multiSelect>
            <div
                class="ui-message ui-widget ui-corner-all ui-message-error ui-messages-error"
                *ngIf="showError"
            >
                <formly-validation-message
                    class="ui-message-text"
                    [field]="field"
                ></formly-validation-message>
            </div>
            <div></div>
        </div>
    `,
})
export class PrimeMultiSelectComponent extends FieldType {}
