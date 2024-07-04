/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { MembershipLevel } from './MembershipLevel';
import type { Name } from './Name';
import type { SnsAccount } from './SnsAccount';
export type Member = {
    id: string;
    name: Name;
    level: MembershipLevel;
    emailAddress: string;
    age: number;
    snsAccounts: Array<SnsAccount>;
};

