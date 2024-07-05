/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
export const $MembershipLevel = {
    title: 'Membership Level',
    description: `The level of membership`,
    type: 'Enum',
    items: [
        {
            key: 'Bronze',
            name: 'Bronze',
            value: 1,
            title: 'Bronze Member',
            description: 'The lowest level of membership',
        },
        {
            key: 'Silver',
            name: 'Silver',
            value: 2,
            title: 'Silver Member',
            description: 'The middle level of membership',
        },
        {
            key: 'Gold',
            name: 'Gold',
            value: 3,
            title: 'Gold Member',
            description: 'The second highest level of membership',
        },
        {
            key: 'Platinum',
            name: 'Platinum',
            value: 4,
            title: 'Platinum Member',
            description: 'The highest level of membership',
        },
    ],
} as const;
