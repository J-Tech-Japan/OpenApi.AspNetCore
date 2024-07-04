/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
export const $Member = {
    properties: {
        id: {
            type: 'string',
            isRequired: true,
            format: 'uuid',
        },
        name: {
            type: 'all-of',
            contains: [{
                type: 'Name',
            }],
            isRequired: true,
        },
        level: {
            type: 'all-of',
            contains: [{
                type: 'MembershipLevel',
            }],
            isRequired: true,
        },
        emailAddress: {
            type: 'string',
            isRequired: true,
            format: 'email',
            minLength: 1,
            pattern: '^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$',
        },
        age: {
            type: 'number',
            isRequired: true,
            format: 'int32',
            maximum: 65,
            minimum: 18,
        },
        snsAccounts: {
            type: 'array',
            contains: {
                type: 'SnsAccount',
            },
            isRequired: true,
        },
    },
} as const;
