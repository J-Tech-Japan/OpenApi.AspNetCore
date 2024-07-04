/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { MembershipLevel } from '../models/MembershipLevel'
export const $MembershipLevel = {
    title: 'Membership Level',
    description: `The level of membership`,
    type: 'Enum',
    items: [
        {
            value: MembershipLevel.Bronze,
            varname: "Bronze",
            title: "Bronze Member",
            description: "The lowest level of membership",
        },
        {
            value: MembershipLevel.Silver,
            varname: "Silver",
            title: "Silver Member",
            description: "The middle level of membership",
        },
        {
            value: MembershipLevel.Gold,
            varname: "Gold",
            title: "Gold Member",
            description: "The second highest level of membership",
        },
        {
            value: MembershipLevel.Platinum,
            varname: "Platinum",
            title: "Platinum Member",
            description: "The highest level of membership",
        },
    ],
} as const;
