import { Component } from '@angular/core';
import { FieldType } from '@ngx-formly/core';

@Component({
    // tslint:disable-next-line: component-selector
    selector: 'prime-select-button',
    template: `
        <div>
            <label style="display:block;"
                >{{ to.label || '' }}{{ to.description || '' }}</label
            >
            <p-selectButton [options]="to.options" [formControl]="formControl">
            </p-selectButton>
        </div>
    `,
})
export class PrimeSelectButtonComponent extends FieldType {}
