/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
export const $SnsAccount = {
    properties: {
        snsService: {
            type: 'all-of',
            contains: [{
                type: 'SnsService',
            }],
            isRequired: true,
        },
        account: {
            type: 'string',
            isRequired: true,
            maxLength: 64,
            minLength: 1,
        },
    },
} as const;
