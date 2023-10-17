import { valueDownmix } from "userplugins/downmix";
import { fakeD } from "userplugins/fake-deafen"; export const ScreenshareSettingsIcon =
    (props: React.ComponentProps<"svg">) =>
        <svg
            xmlns="http://www.w3.org/2000/svg"
            width="1000"
            height="1000"
            viewBox="0 0 1000 1000"
            {...props}
        >
            <defs>
                <mask id="screenshareSettingsIconMask">
                    <path
                        fill="currentColor"
                        fillRule="evenodd"
                        d="M2 4.5c0-1.103.897-2 2-2h16c1.103 0 2 .897 2 2v11c0 1.104-.897 2-2 2h-7v2h4v2H7v-2h4v-2H4c-1.103 0-2-.896-2-2v-11zm11.2 9.838V11.6c-3.336 0-5.532 1.063-7.2 3.4.672-3.338 2.532-6.662 7.2-7.338V5L18 9.662l-4.8 4.675z"
                        transform="matrix(43.2813 0 0 43.3063 567.187 588.59) translate(-12 -12)"
                        vectorEffect="non-scaling-stroke"
                    ></path>
                    <path
                        fill="#000"
                        strokeWidth="0"
                        // Circle
                        d="M132.5 67.5c0 35.899-29.101 65-65 65-35.898 0-65-29.101-65-65 0-35.898 29.102-65 65-65 35.899 0 65 29.102 65 65z"
                        transform="translate(229.14 230.807) scale(4.9157) translate(-67.5 -67.5)"
                        vectorEffect="non-scaling-stroke"
                    ></path>
                </mask>
            </defs>
            <rect width="100%" height="100%" fill="var(--interactive-normal)" mask="url(#screenshareSettingsIconMask)"></rect>
            <path
                fill="currentColor"
                fillRule="evenodd"
                strokeWidth="0"
                // Settings Icon
                d="M19.738 10H22v4h-2.261a7.952 7.952 0 01-1.174 2.564L20 18l-2 2-1.435-1.436A7.946 7.946 0 0114 19.738V22h-4v-2.262a7.94 7.94 0 01-2.564-1.174L6 20l-2-2 1.436-1.436A7.911 7.911 0 014.262 14H2v-4h2.262a7.9 7.9 0 011.174-2.564L4 6l2-2 1.436 1.436A7.9 7.9 0 0110 4.262V2h4v2.261a7.967 7.967 0 012.565 1.174L18 3.999l2 2-1.436 1.437A7.93 7.93 0 0119.738 10zM12 16a4 4 0 100-8 4 4 0 000 8z"
                transform="translate(229.812 230.81) scale(23.0217) translate(-12 -12)"
                vectorEffect="non-scaling-stroke"
            ></path>
        </svg>;

export const CameraSettingsIcon =
    (props: React.ComponentProps<"svg">) =>
        <svg
            xmlns="http://www.w3.org/2000/svg"
            width="1000"
            height="1000"
            viewBox="0 0 1000 1000"
            {...props}
        >
            <defs>
                <mask id="m">
                    <path
                        fill="currentColor"
                        fillRule="evenodd"
                        d="M21.526 8.149a1 1 0 00-.973-.044L18 9.382V7c0-1.103-.897-2-2-2H4c-1.103 0-2 .897-2 2v10c0 1.104.897 2 2 2h12c1.103 0 2-.896 2-2v-2.382l2.553 1.276a.992.992 0 00.973-.043c.294-.183.474-.504.474-.851V9c0-.347-.18-.668-.474-.851z"
                        transform="translate(586.527 617.666) scale(41.3472) translate(-12 -12)"
                        vectorEffect="non-scaling-stroke"
                    ></path>
                    <path
                        fill="#000"
                        strokeWidth="0"
                        // Circle
                        d="M132.5 67.5c0 35.899-29.101 65-65 65-35.898 0-65-29.101-65-65 0-35.898 29.102-65 65-65 35.899 0 65 29.102 65 65z"
                        transform="translate(229.14 230.807) scale(4.9157) translate(-67.5 -67.5)"
                        vectorEffect="non-scaling-stroke"
                    ></path>
                </mask>
            </defs>
            <rect width="100%" height="100%" fill="var(--interactive-normal)" mask="url(#m)"></rect>
            <path
                fill="currentColor"
                fillRule="evenodd"
                strokeWidth="0"
                // Settings Icon
                d="M19.738 10H22v4h-2.261a7.952 7.952 0 01-1.174 2.564L20 18l-2 2-1.435-1.436A7.946 7.946 0 0114 19.738V22h-4v-2.262a7.94 7.94 0 01-2.564-1.174L6 20l-2-2 1.436-1.436A7.911 7.911 0 014.262 14H2v-4h2.262a7.9 7.9 0 011.174-2.564L4 6l2-2 1.436 1.436A7.9 7.9 0 0110 4.262V2h4v2.261a7.967 7.967 0 012.565 1.174L18 3.999l2 2-1.436 1.437A7.93 7.93 0 0119.738 10zM12 16a4 4 0 100-8 4 4 0 000 8z"
                transform="translate(229.812 230.81) scale(23.0217) translate(-12 -12)"
                vectorEffect="non-scaling-stroke"
            ></path>
        </svg>;

export const MicrophoneSettingsIcon =
    (props: React.ComponentProps<"svg">) =>
        <svg
            xmlns="http://www.w3.org/2000/svg"
            width="1000"
            height="1000"
            viewBox="0 0 1000 1000"
            {...props}
        >
            <defs>
                <mask id="microphoneSettingsIcon">
                    <path
                        fill="currentColor"
                        fillRule="evenodd"
                        d="M14.99 11c0 1.66-1.33 3-2.99 3-1.66 0-3-1.34-3-3V5c0-1.66 1.34-3 3-3s3 1.34 3 3l-.01 6zM12 16.1c2.76 0 5.3-2.1 5.3-5.1H19c0 3.42-2.72 6.24-6 6.72V21h-2v-3.28c-3.28-.49-6-3.31-6-6.72h1.7c0 3 2.54 5.1 5.3 5.1zM12 4c-.8 0-1 .667-1 1v6c0 .333.2 1 1 1s1-.667 1-1V5c0-.333-.2-1-1-1z"
                        transform="translate(689.616 574.556) scale(48.6222) translate(0 -.417) scale(.8333) translate(-12 -11.5)"
                    ></path>
                    <path
                        fill="currentColor"
                        fillRule="evenodd"
                        d="M14.99 11c0 1.66-1.33 3-2.99 3-1.66 0-3-1.34-3-3V5c0-1.66 1.34-3 3-3s3 1.34 3 3l-.01 6zM12 16.1c2.76 0 5.3-2.1 5.3-5.1H19c0 3.42-2.72 6.24-6 6.72V22h-2v-4.28c-3.28-.49-6-3.31-6-6.72h1.7c0 3 2.54 5.1 5.3 5.1z"
                        transform="translate(689.616 574.556) scale(48.6222) scale(.8333) translate(-12 -12)"
                    ></path>
                    <path
                        fill="#000"
                        strokeWidth="0"
                        // Circle
                        d="M132.5 67.5c0 35.899-29.101 65-65 65-35.898 0-65-29.101-65-65 0-35.898 29.102-65 65-65 35.899 0 65 29.102 65 65z"
                        transform="translate(229.14 230.807) scale(4.9157) translate(-67.5 -67.5)"
                        vectorEffect="non-scaling-stroke"
                    ></path>
                </mask>
            </defs>
            <rect width="100%" height="100%" fill="var(--interactive-normal)" mask="url(#microphoneSettingsIcon)"></rect>
            <path
                fill="currentColor"
                fillRule="evenodd"
                strokeWidth="0"
                // Settings Icon
                d="M19.738 10H22v4h-2.261a7.952 7.952 0 01-1.174 2.564L20 18l-2 2-1.435-1.436A7.946 7.946 0 0114 19.738V22h-4v-2.262a7.94 7.94 0 01-2.564-1.174L6 20l-2-2 1.436-1.436A7.911 7.911 0 014.262 14H2v-4h2.262a7.9 7.9 0 011.174-2.564L4 6l2-2 1.436 1.436A7.9 7.9 0 0110 4.262V2h4v2.261a7.967 7.967 0 012.565 1.174L18 3.999l2 2-1.436 1.437A7.93 7.93 0 0119.738 10zM12 16a4 4 0 100-8 4 4 0 000 8z"
                transform="translate(229.812 230.81) scale(23.0217) translate(-12 -12)"
                vectorEffect="non-scaling-stroke"
            ></path>
        </svg>;
export const StereoIcon = (props: React.ComponentProps<"svg">) => {
    const isDownmix = parseInt(valueDownmix);

    return (
        <svg
            aria-hidden="true"
            role="img"
            width="24"
            height="24"
            viewBox={!isDownmix ? "0 0 24 24" : "0 0 48 48"}
            xmlns="http://www.w3.org/2000/svg"
        >
            {!isDownmix ? (
                <>
                    {
                        <><path d="M10.889 4C10.889 3.44772 11.3367 3 11.889 3H12.1112C12.6635 3 13.1112 3.44772 13.1112 4V20C13.1112 20.5523 12.6635 21 12.1112 21H11.889C11.3367 21 10.889 20.5523 10.889 20V4Z" fill="var(--interactive-normal)"></path><path d="M6.44439 6.25C6.44439 5.69772 6.89211 5.25 7.44439 5.25H7.66661C8.2189 5.25 8.66661 5.69772 8.66661 6.25V17.75C8.66661 18.3023 8.2189 18.75 7.66661 18.75H7.44439C6.89211 18.75 6.44439 18.3023 6.44439 17.75V6.25Z" fill="var(--interactive-normal)"></path><path d="M3.22222 15.375C3.77451 15.375 4.22222 14.9273 4.22222 14.375L4.22222 9.625C4.22222 9.07272 3.77451 8.625 3.22222 8.625H3C2.44772 8.625 2 9.07272 2 9.625V14.375C2 14.9273 2.44772 15.375 3 15.375H3.22222Z" fill="var(--interactive-normal)"></path><path d="M22.0001 13.25C22.0001 13.8023 21.5523 14.25 21.0001 14.25H20.7778C20.2255 14.25 19.7778 13.8023 19.7778 13.25V10.75C19.7778 10.1977 20.2255 9.75 20.7778 9.75H21.0001C21.5523 9.75 22.0001 10.1977 22.0001 10.75V13.25Z" fill="var(--interactive-normal)"></path><path d="M16.3333 7.5C15.781 7.5 15.3333 7.94772 15.3333 8.5V15.5C15.3333 16.0523 15.781 16.5 16.3333 16.5H16.5555C17.1078 16.5 17.5555 16.0523 17.5555 15.5V8.5C17.5555 7.94772 17.1078 7.5 16.5555 7.5H16.3333Z" fill="var(--interactive-normal)"></path></>
                    }
                </>
            ) : (
                <>
                    {
                        <><path d="M30.6666 24.9644L35.1111 20.5199V31C35.1111 32.1046 34.2156 33 33.1111 33H32.6666C31.562 33 30.6666 32.1046 30.6666 31V24.9644Z" fill="var(--interactive-normal)"></path><path d="M26.2224 14.1463V8C26.2224 6.89543 25.327 6 24.2224 6H23.7779C22.6734 6 21.7779 6.89543 21.7779 8V18.5907L26.2224 14.1463Z" fill="var(--interactive-normal)"></path><path d="M21.7779 33.8543L21.9254 33.7056L26.2224 29.4086V40C26.2224 41.1046 25.327 42 24.2224 42H23.7779C22.6734 42 21.7779 41.1046 21.7779 40V33.8543Z" fill="var(--interactive-normal)"></path><path d="M17.3332 23.0354L12.8888 27.4799V12.5C12.8888 11.3954 13.7842 10.5 14.8888 10.5H15.3332C16.4378 10.5 17.3332 11.3954 17.3332 12.5V23.0354Z" fill="var(--interactive-normal)"></path><path d="M8.44445 28.75C8.44445 29.8546 7.54902 30.75 6.44445 30.75H6C4.89543 30.75 4 29.8546 4 28.75V19.25C4 18.1454 4.89543 17.25 6 17.25H6.44445C7.54902 17.25 8.44445 18.1454 8.44445 19.25L8.44445 28.75Z" fill="var(--interactive-normal)"></path><path d="M44.0001 26.5C44.0001 27.6046 43.1047 28.5 42.0001 28.5H41.5557C40.4511 28.5 39.5557 27.6046 39.5557 26.5V21.5C39.5557 20.3954 40.4511 19.5 41.5557 19.5H42.0001C43.1047 19.5 44.0001 20.3954 44.0001 21.5V26.5Z" fill="var(--interactive-normal)"></path><path d="M42 8.54L39.46 6L6 39.46L8.54 42L16.92 33.64L19.38 31.16L22.7 27.84L29.98 20.56L42 8.54Z" fill="currentColor"></path></>
                    }
                </>
            )}
        </svg>
    );
};

export const DeafenIcon = (props: React.ComponentProps<"svg">) => {
    const isFakeD = fakeD;

    return (
        <svg
            aria-hidden="true"
            role="img"
            width="20"
            height="20"
            viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg"
        >
            {isFakeD ? (
                <>
                    {
                        <><svg width="24" height="24" viewBox="0 0 24 24"><path d="M12 2.00305C6.486 2.00305 2 6.48805 2 12.0031V20.0031C2 21.1071 2.895 22.0031 4 22.0031H6C7.104 22.0031 8 21.1071 8 20.0031V17.0031C8 15.8991 7.104 15.0031 6 15.0031H4V12.0031C4 7.59105 7.589 4.00305 12 4.00305C16.411 4.00305 20 7.59105 20 12.0031V15.0031H18C16.896 15.0031 16 15.8991 16 17.0031V20.0031C16 21.1071 16.896 22.0031 18 22.0031H20C21.104 22.0031 22 21.1071 22 20.0031V12.0031C22 6.48805 17.514 2.00305 12 2.00305Z" fill="var(--interactive-normal)"></path></svg></>
                    }
                </>
            ) : (
                <>
                    {
                        <><path d="M6.16204 15.0065C6.10859 15.0022 6.05455 15 6 15H4V12C4 7.588 7.589 4 12 4C13.4809 4 14.8691 4.40439 16.0599 5.10859L17.5102 3.65835C15.9292 2.61064 14.0346 2 12 2C6.486 2 2 6.485 2 12V19.1685L6.16204 15.0065Z" fill="var(--interactive-normal)"></path><path d="M19.725 9.91686C19.9043 10.5813 20 11.2796 20 12V15H18C16.896 15 16 15.896 16 17V20C16 21.104 16.896 22 18 22H20C21.105 22 22 21.104 22 20V12C22 10.7075 21.7536 9.47149 21.3053 8.33658L19.725 9.91686Z" fill="var(--interactive-normal)"></path><path d="M3.20101 23.6243L1.7868 22.2101L21.5858 2.41113L23 3.82535L3.20101 23.6243Z" fill="currentColor"></path></>
                    }
                </>
            )}
        </svg>
    );
};