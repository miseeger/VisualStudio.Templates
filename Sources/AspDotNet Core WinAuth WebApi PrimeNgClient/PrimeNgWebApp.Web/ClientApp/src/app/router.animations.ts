import {
    trigger,
    animate,
    style,
    group,
    query,
    transition,
} from '@angular/animations';

export const routerAnimation = trigger('animateRouting', [
    transition('* => *', [
        query(':enter, :leave', [style({ position: 'fixed', opacity: 0, width: 'auto' })], {
            optional: true,
        }),
        query(
            ':leave',
            [style({ opacity: 1 }), animate('0.3s', style({ opacity: 0 }))],
            { optional: true }
        ),
        query(
            ':enter',
            [style({ opacity: 0 }), animate('0.3s', style({ opacity: 1 }))],
            { optional: true }
        ),
    ]),
]);


export const routerAnimation2 = trigger('animateRouting2', [
    transition('* <=> *', [
        query(':enter, :leave', style({ position: 'fixed', width: '100%' }), {
            optional: true,
        }),
        group([
            query(
                ':enter',
                [
                    style({ transform: 'translateX(100%)' }),
                    animate(
                        '0.5s ease-in-out',
                        style({ transform: 'translateX(0%)' })
                    ),
                ],
                { optional: true }
            ),
            query(
                ':leave',
                [
                    style({ transform: 'translateX(0%)' }),
                    animate(
                        '0.5s ease-in-out',
                        style({ transform: 'translateX(-100%)' })
                    ),
                ],
                { optional: true }
            ),
        ]),
    ]),
]);
