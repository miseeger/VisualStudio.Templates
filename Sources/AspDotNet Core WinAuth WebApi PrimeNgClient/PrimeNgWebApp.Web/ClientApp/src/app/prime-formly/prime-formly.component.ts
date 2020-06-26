import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormlyFieldConfig, FormlyFormOptions } from '@ngx-formly/core';
import { startWith, switchMap } from 'rxjs/operators';

import { PrimeFormlyService } from '../_services/prime-formly.service';

@Component({
    selector: 'app-formly',
    templateUrl: './prime-formly.component.html',
    styleUrls: ['./prime-formly.component.css'],
})
export class PrimeFormlyComponent {
    form = new FormGroup({});

    model = {
        id: 4711,
        firstname: 'Michael',
        age: '55',
        nationId: 2,
        cityId: 1,
        ip: '',
        ipSeverity: 'Medium',
        everOwnedCarMakes: ['Peugeot', 'Mazda'],
    };

    fields: FormlyFieldConfig[] = [
        {
            key: 'id',
        },
        {
            fieldGroupClassName: 'p-grid',
            fieldGroup: [
                {
                    key: 'firstname',
                    type: 'input',
                    className: 'p-col-8',
                    templateOptions: {
                        label: 'Firstname',
                        required: true,
                    },
                    validation: {
                        required: true,
                    },
                },
                {
                    key: 'age',
                    type: 'input',
                    className: 'p-col-4',
                    templateOptions: {
                        type: 'number',
                        label: 'Age',
                        min: 18,
                    },
                    validation: {
                        messages: {
                            min: 'Sorry, you must be at least 18.',
                        },
                    },
                },
            ],
        },
        {
            fieldGroupClassName: 'p-grid',
            fieldGroup: [
                {
                    key: 'nationId',
                    type: 'select',
                    className: 'p-col-6',
                    templateOptions: {
                        label: 'Country',
                        options: this.pfService.getNations(),
                    },
                },
                {
                    key: 'cityId',
                    type: 'select',
                    className: 'p-col-6',
                    templateOptions: {
                        label: 'City',
                        options: [],
                    },
                    expressionProperties: {
                        // 'templateOptions.disabled': (model) => !model.nationId,
                        'model.cityid': '!model.nationId ? null : model.cityId',
                    },
                    hideExpression: '!model.nationId',
                    hooks: {
                        onInit: (field: FormlyFieldConfig) => {
                            field.templateOptions.options = field.form
                                .get('nationId')
                                .valueChanges.pipe(
                                    startWith(this.model.nationId),
                                    switchMap((nationId) =>
                                        this.pfService.getCities(nationId)
                                    )
                                );
                        },
                    },
                },
            ],
        },
        {
            fieldGroupClassName: 'p-grid',
            fieldGroup: [
                {
                    key: 'ip',
                    type: 'input',
                    className: 'p-col-6',
                    templateOptions: {
                        label: 'IP-Address',
                        required: true,
                    },
                    validators: {
                        validation: ['ip'],
                    },
                },
                {
                    key: 'ipSeverity',
                    type: 'selectbutton',
                    className: 'p-col-6',
                    templateOptions: {
                        description: ' - your choice?',
                        label: 'IP Severity Level',
                        options: [
                            { label: 'High', value: 'High' },
                            { label: 'Medium', value: 'Medium' },
                            { label: 'Low', value: 'Low' },
                        ],
                    },
                },
            ],
        },
        {
            fieldGroupClassName: 'p-grid',
            fieldGroup: [
                {
                    key: 'everOwnedCarMakes',
                    type: 'multiselect',
                    className: 'p-col-12',
                    templateOptions: {
                        label: 'Ever Owned Car Makes',
                        options: [
                            { label: 'Audi', value: 'Audi' },
                            { label: 'BMW', value: 'BMW' },
                            { label: 'Fiat', value: 'Fiat' },
                            { label: 'Ford', value: 'Ford' },
                            { label: 'Honda', value: 'Honda' },
                            { label: 'Mazda', value: 'Mazda' },
                            { label: 'Jaguar', value: 'Jaguar' },
                            { label: 'Mercedes', value: 'Mercedes' },
                            { label: 'Peugeot', value: 'Peugeot' },
                            { label: 'VW', value: 'VW' },
                            { label: 'Volvo', value: 'Volvo' },
                        ],
                        required: true,
                    },
                },
            ],
        },
    ];

    options: FormlyFormOptions = {};

    constructor(private pfService: PrimeFormlyService) {}

    onSubmit({ valid, value }) {
        // tslint:disable-next-line: no-console
        console.info(value);
    }
}
